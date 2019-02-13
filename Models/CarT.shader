Shader "custom/headshader" {

	Properties
	{
		_Color("Main Color", Color) = (1,1,1,1)
		_MainTex("Base (RGBA)", 2D) = "white" {}
	}
		SubShader
	{
		Tags { "RenderType" = "Opaque" }
		LOD 250

		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;
		fixed4 _Color;

		struct Input
		{
			float2 uv_MainTex;
			float2 uv_DecalTex;
		};

		void surf(Input IN, inout SurfaceOutput o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = lerp(_Color, c.rgb, c.a);
			o.Alpha = 1;
		}
		ENDCG
	}
		Fallback "Diffuse"
}