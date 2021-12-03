Shader "WeaponShader" {
Properties {
	_Color ("Main Color", Color) = (1,1,1,1)
	_SpecColor ("Specular Color", Color) = (0.5, 0.5, 0.5, 1)
	_Shininess ("Shininess", Range (0.03, 1)) = 0.078125
	_Reflection ("Reflection Amount", Color) = (0.5, 0.5, 0.5, 1)
	_MainTex ("Base (RGB) Gloss (A)", 2D) = "white" {}
	_BumpMap ("Normalmap", 2D) = "bump" {}
	_SpecMap ("Specular map", 2D) = "black" {}
	_Cube ("Cubemap", CUBE) = "" {}
}
SubShader { 
	Tags { "RenderType"="Opaque" }
	LOD 400
	
CGPROGRAM
#pragma surface surf BlinnPhong
#pragma target 3.0


sampler2D _MainTex;
sampler2D _BumpMap;
sampler2D _SpecMap;
samplerCUBE _Cube;
fixed4 _Color;
half _Shininess;
fixed4 _Reflection;


struct Input {
	float2 uv_MainTex;
	float2 uv_BumpMap;
	float2 uv_SpecMap;
	float3 worldRefl;
	INTERNAL_DATA
};

void surf (Input IN, inout SurfaceOutput o) {
	fixed4 mainTex = tex2D(_MainTex, IN.uv_MainTex);
	fixed4 specTex = tex2D(_SpecMap, IN.uv_MainTex);
	o.Albedo = mainTex.rgb * _Color.rgb;
	o.Gloss = specTex.rgb; // lighting function gets gloss and spec mixed up so here we remedy that
	o.Specular = mainTex.a * _Shininess; // lighting function gets gloss and spec mixed up so here we remedy that
	o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_MainTex));
	o.Emission = texCUBE (_Cube, WorldReflectionVector (IN, o.Normal)).rgb * mainTex.a * _Reflection.rgb;
}
ENDCG
}

FallBack "Specular"
}