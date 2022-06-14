#version 460 core

layout (location = 0) in vec3 aPos;
layout (location = 1) in vec2 aTexCoord;

uniform mat4 uProj;
uniform mat4 uModel;
uniform mat4 uView;

out vec3 fragPos;
out vec2 texCoord;

void main()
{
	vec4 pos = uProj * uView * uModel * vec4(aPos, 1.0f);
	gl_Position = pos;
	fragPos = vec3(uModel * vec4(aPos, 1.0));
	normal = aNormal;
	texCoord = aTexCoord;
}