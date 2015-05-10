// Shader created with Shader Forge Beta 0.36 
// Shader Forge (c) Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:0.36;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:1,uamb:True,mssp:True,lmpd:False,lprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,blpr:0,bsrc:0,bdst:0,culm:0,dpts:2,wrdp:True,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1,x:32015,y:32984|diff-8-OUT,spec-49-OUT,normal-58-RGB,amdfl-82-OUT;n:type:ShaderForge.SFN_Tex2d,id:2,x:32973,y:32612,ptlb:Diffuse,ptin:_Diffuse,tex:38c9a786da940624eaae8a1d4c3ea489,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:8,x:32726,y:32573|A-17-OUT,B-2-RGB;n:type:ShaderForge.SFN_Color,id:9,x:33083,y:32342,ptlb:Diffuse Color,ptin:_DiffuseColor,glob:False,c1:0.2373226,c2:0.2150735,c3:0.8602941,c4:1;n:type:ShaderForge.SFN_Vector1,id:15,x:33108,y:32536,v1:3;n:type:ShaderForge.SFN_Multiply,id:17,x:32834,y:32405|A-9-RGB,B-15-OUT;n:type:ShaderForge.SFN_Tex2d,id:40,x:32976,y:33013,ptlb:Specular,ptin:_Specular,tex:bc4584ede64f35542a23983fea8608b1,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:47,x:32976,y:32843,ptlb:Specular Color,ptin:_SpecularColor,glob:False,c1:0.9117647,c2:0.6437835,c3:0.06704153,c4:1;n:type:ShaderForge.SFN_Multiply,id:49,x:32795,y:32853|A-47-RGB,B-40-RGB;n:type:ShaderForge.SFN_Tex2d,id:58,x:32976,y:33212,ptlb:Normal Map,ptin:_NormalMap,tex:66a0380fcb383d149ab1d1f833dfcac6,ntxv:3,isnm:True;n:type:ShaderForge.SFN_NormalVector,id:64,x:33179,y:33349,pt:False;n:type:ShaderForge.SFN_Fresnel,id:65,x:32962,y:33469|NRM-64-OUT,EXP-66-OUT;n:type:ShaderForge.SFN_ValueProperty,id:66,x:33179,y:33547,ptlb:Rim Power,ptin:_RimPower,glob:False,v1:3;n:type:ShaderForge.SFN_Multiply,id:72,x:32681,y:33595|A-65-OUT,B-75-OUT;n:type:ShaderForge.SFN_ValueProperty,id:75,x:32852,y:33685,ptlb:Intensity,ptin:_Intensity,glob:False,v1:3;n:type:ShaderForge.SFN_Color,id:81,x:32880,y:33797,ptlb:Rim Color,ptin:_RimColor,glob:False,c1:0.4068966,c2:0,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:82,x:32426,y:33605|A-72-OUT,B-81-RGB;proporder:2-9-40-47-58-66-75-81;pass:END;sub:END;*/

Shader "Shader Forge/TreeShader" {
    Properties {
        _Diffuse ("Diffuse", 2D) = "white" {}
        _DiffuseColor ("Diffuse Color", Color) = (0.2373226,0.2150735,0.8602941,1)
        _Specular ("Specular", 2D) = "white" {}
        _SpecularColor ("Specular Color", Color) = (0.9117647,0.6437835,0.06704153,1)
        _NormalMap ("Normal Map", 2D) = "bump" {}
        _RimPower ("Rim Power", Float ) = 3
        _Intensity ("Intensity", Float ) = 3
        _RimColor ("Rim Color", Color) = (0.4068966,0,1,1)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "ForwardBase"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float4 _DiffuseColor;
            uniform sampler2D _Specular; uniform float4 _Specular_ST;
            uniform float4 _SpecularColor;
            uniform sampler2D _NormalMap; uniform float4 _NormalMap_ST;
            uniform float _RimPower;
            uniform float _Intensity;
            uniform float4 _RimColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 binormalDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(float4(v.normal,0), _World2Object).xyz;
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.binormalDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.binormalDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
/////// Normals:
                float2 node_96 = i.uv0;
                float3 normalLocal = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(node_96.rg, _NormalMap))).rgb;
                float3 normalDirection =  normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 diffuse = max( 0.0, NdotL) * attenColor + UNITY_LIGHTMODEL_AMBIENT.rgb;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                NdotL = max(0.0, NdotL);
                float3 specularColor = (_SpecularColor.rgb*tex2D(_Specular,TRANSFORM_TEX(node_96.rg, _Specular)).rgb);
                float3 specular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow) * specularColor;
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                diffuseLight += ((pow(1.0-max(0,dot(i.normalDir, viewDirection)),_RimPower)*_Intensity)*_RimColor.rgb); // Diffuse Ambient Light
                finalColor += diffuseLight * ((_DiffuseColor.rgb*3.0)*tex2D(_Diffuse,TRANSFORM_TEX(node_96.rg, _Diffuse)).rgb);
                finalColor += specular;
/// Final Color:
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ForwardAdd"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            Fog { Color (0,0,0,0) }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float4 _DiffuseColor;
            uniform sampler2D _Specular; uniform float4 _Specular_ST;
            uniform float4 _SpecularColor;
            uniform sampler2D _NormalMap; uniform float4 _NormalMap_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 binormalDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(float4(v.normal,0), _World2Object).xyz;
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.binormalDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.binormalDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
/////// Normals:
                float2 node_97 = i.uv0;
                float3 normalLocal = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(node_97.rg, _NormalMap))).rgb;
                float3 normalDirection =  normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 diffuse = max( 0.0, NdotL) * attenColor;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                NdotL = max(0.0, NdotL);
                float3 specularColor = (_SpecularColor.rgb*tex2D(_Specular,TRANSFORM_TEX(node_97.rg, _Specular)).rgb);
                float3 specular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow) * specularColor;
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                finalColor += diffuseLight * ((_DiffuseColor.rgb*3.0)*tex2D(_Diffuse,TRANSFORM_TEX(node_97.rg, _Diffuse)).rgb);
                finalColor += specular;
/// Final Color:
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
