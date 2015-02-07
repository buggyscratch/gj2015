using UnityEngine;
using System.Collections;

public class PerlinNoise
{
		const int SIZE = 512;	// 512 or 256 (power of two)
		const int hashMask = SIZE - 1;
		private int[] perm = new int[SIZE + SIZE]; // 1024
		
		private static Vector2[] gradients2D = {
			new Vector2 (1f, 0f),
			new Vector2 (-1f, 0f),
			new Vector2 (0f, 1f),
			new Vector2 (0f, -1f),
			new Vector2 (1f, 1f).normalized,
			new Vector2 (-1f, 1f).normalized,
			new Vector2 (1f, -1f).normalized,
			new Vector2 (-1f, -1f).normalized
};
		private const int gradientsMask2D = 7;
	
		/**
	 * **********************
	 * some code explanation
	 * **********************
	 **/
		public PerlinNoise (int seed)
		{
				UnityEngine.Random.seed = seed;
		
				int i, j, k;
				for (i = 0; i < SIZE; i++) {
						// creates 0 - 512
						perm [i] = i;
				}
				
				// Fisher-Yates algorithm method 1
				/*while (i > 1) {
						i--;
						k = perm [i];
						j = UnityEngine.Random.Range (0, SIZE);
						perm [i] = perm [j];
						perm [j] = k;
				}*/
				
				// Fisher-Yates algorithm method 2
				for (i = SIZE - 1; i > 0; i--) {
						j = UnityEngine.Random.Range (0, SIZE);
						k = perm [j];
						perm [j] = perm [i];
						perm [i] = k;
				}    
		
				for (i = 0; i < SIZE; i++) {
						perm [SIZE + i] = perm [i];
				}
		}

		/**
	 * **********************
	 * 	6t^5 - 15t^4 + 10t^3
	 * **********************
	 **/
		float Smooth (float t)
		{			
				//return Mathf.Pow(t*t*t,2) - Mathf.Pow(t*t*t,3);;
				return t * t * t * (t * (t * 6.0f - 15.0f) + 10.0f);
		}

		/**
	 * **********************
	 * some code explanation
	 * **********************
	 **/
		private static float Dot (Vector2 g, float x, float y)
		{
				return g.x * x + g.y * y;
		}
	
		/**
	 * **********************
	 * some code explanation
	 * **********************
	 **/
		public float Perlin2D (Vector3 point, float frequency)
		{
				point *= frequency;
				int ix0 = Mathf.FloorToInt (point.x);
				int iy0 = Mathf.FloorToInt (point.y);
				float tx0 = point.x - ix0;
				float ty0 = point.y - iy0;
				float tx1 = tx0 - 1f;
				float ty1 = ty0 - 1f;
				ix0 &= hashMask;
				iy0 &= hashMask;
				int ix1 = (ix0 + 1) & hashMask;
				int iy1 = (iy0 + 1) & hashMask;

				Vector2 g00 = gradients2D [perm [perm [ix0] + iy0] & gradientsMask2D];
				Vector2 g10 = gradients2D [perm [perm [ix1] + iy0] & gradientsMask2D];
				Vector2 g01 = gradients2D [perm [perm [ix0] + iy1] & gradientsMask2D];
				Vector2 g11 = gradients2D [perm [perm [ix1] + iy1] & gradientsMask2D];

				float v00 = Dot (g00, tx0, ty0);
				float v10 = Dot (g10, tx1, ty0);
				float v01 = Dot (g01, tx0, ty1);
				float v11 = Dot (g11, tx1, ty1);

				float tx = Smooth (tx0);
				float ty = Smooth (ty0);
				return Mathf.Lerp (
					Mathf.Lerp (v00, v10, tx),
					Mathf.Lerp (v01, v11, tx),
				ty) * (2 - 0.41421356237f); // Mathf.Sqrt(2) = 1.414...;
		}

		/**
	 * **********************
	 * Implementation of noise
	 * **********************
	 **/
		public float Noise (Vector2 point)
		{
				int x = Mathf.FloorToInt (point.x);
				int y = Mathf.FloorToInt (point.y);
				x &= SIZE;
				y &= SIZE;
				int v = perm [x + y];
				v &= SIZE;
				return v / 2;
		}


		/**
	 * **********************
	 * Implementation of 2D fractal perlin noise
	 * **********************
	 **/
		public float FractalNoise2D (Vector3 point, int octaves, float frequency, float lacunarity, float persistence, float gain)
		{
				float sum = Perlin2D (point, frequency);
				float amplitude = 1f;
				float range = 1f;
				for (int o = 1; o < octaves; o++) {
						frequency *= lacunarity;
						amplitude *= persistence;
						range += amplitude;
						sum += Perlin2D (point, frequency) * amplitude;
				}
				return (sum / range) * gain;
		}
}
