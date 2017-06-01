// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Sprites-Multiple" 
{
	Properties
	{
		[PerRendererData] _MainTex ("Sprite Texture", 2DArray) = "white" {}
		_Color ("Tint", Color) = (1,1,1,1)
		[MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
		[HideInInspector] _RendererColor ("RendererColor", Color) = (1,1,1,1)
		[HideInInspector] _Flip ("Flip", Vector) = (1,1,1,1)
		[PerRendererData] _AlphaTex ("External Alpha", 2D) = "white" {}
		[PerRendererData] _EnableExternalAlpha ("Enable External Alpha", Float) = 0
	}

	SubShader
	{
		Tags
		{ 
			"Queue"="Transparent" 
			"IgnoreProjector"="True" 
			"RenderType"="Transparent" 
			"PreviewType"="Plane" 
			"CanUseSpriteAtlas"="True"
		}

		Cull Off
		Lighting Off
		ZWrite Off
		Blend One OneMinusSrcAlpha

		Pass
		{
		CGPROGRAM
			#pragma vertex SpriteVert
			#pragma fragment SpriteFrag
			#pragma target 2.0
			#pragma multi_compile_instancing
			#pragma multi_compile _ PIXELSNAP_ON
			#pragma multi_compile _ ETC1_EXTERNAL_ALPHA
			#include "UnitySprites.cginc"

			sampler2D _MainTex;
			float4 _Color;

			struct Vertex
			{
			float4 vertex : POSITION;
			float2 uv_MainTex : TEXCOORD0;
			float2 uv2 : TEXCOORD1;
			};
			struct Fragment
			{
			float4 vertex : POSITION;
			float2 uv_MainTex : TEXCOORD0;
			float2 uv2 : TEXCOORD1;
			};

			Fragment vert(Vertex v)
			{
			Fragment o;

			o.vertex = UnityObjectToClipPos(v.vertex);
			o.uv_MainTex = v.uv_MainTex;
			o.uv2 = v.uv2;

			return o;
			}


			float4 frag(Fragment IN) : COLOR
			{
			float4 o = float4(1, 0, 0, 0.2);

			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			o.rgb = c.rgb;
			if(c.r == _Color.r && c.g== _Color.g && c.b == _Color.b
			{
			o.a = 0;
			}
			else
			{
			o.a = 1;
			}
			return o;
			}

		ENDCG
		}
	}
}

