# Guard Key

## Introduction
Guardkey adds a layer of authentication, via tokenisation. It is not to be confused with two factor authentication, as it's on the same device.
It works by creating a unque token based off time, a usernames credentials and a private stored server key. These are then put into a windows based 
program and a token produced. This is placed into the web app which then repeates the same process, using the information it has, and compares. 

## Usage
This can be used to bolster existing authentication security, for example having a requirement to use guard key on every third login.

## Examples
There is included a php example of implimenting server side, and an uncompliled version of the c# windows program. This will need compiling in visual studio. 
