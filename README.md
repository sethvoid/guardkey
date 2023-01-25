
  ______                                       __        __    __                     
 /      \                                     /  |      /  |  /  |                    
/$$$$$$  | __    __   ______    ______    ____$$ |      $$ | /$$/   ______   __    __ 
$$ | _$$/ /  |  /  | /      \  /      \  /    $$ |      $$ |/$$/   /      \ /  |  /  |
$$ |/    |$$ |  $$ | $$$$$$  |/$$$$$$  |/$$$$$$$ |      $$  $$<   /$$$$$$  |$$ |  $$ |
$$ |$$$$ |$$ |  $$ | /    $$ |$$ |  $$/ $$ |  $$ |      $$$$$  \  $$    $$ |$$ |  $$ |
$$ \__$$ |$$ \__$$ |/$$$$$$$ |$$ |      $$ \__$$ |      $$ |$$  \ $$$$$$$$/ $$ \__$$ |
$$    $$/ $$    $$/ $$    $$ |$$ |      $$    $$ |      $$ | $$  |$$       |$$    $$ |
 $$$$$$/   $$$$$$/   $$$$$$$/ $$/        $$$$$$$/       $$/   $$/  $$$$$$$/  $$$$$$$ |
                                                                            /  \__$$ |
                                                                            $$    $$/ 
                                                                             $$$$$$/ 

## Introduction
Guardkey adds a layer of authentication, via tokenisation. It is not to be confused with two factor authentication, as it's on the same device, but its an 'on the fly' token generation via a c# application.
It works by creating a unque token based off time, a usernames credentials and a private stored server key. These are then put into a windows based 
program and a token produced. This is placed into the web app which then repeates the same process, using the information it has, and compares. 

## Advantages
Some web applications (or other types of applications) can not practically impliment two factor authentication, so I created this simple framework to help add an extra layer of security. the 'guardkey' is installed locally on a machine and the user uses there username and password to generate a token with an expiration date, its a similar process to how an ssh key is produced. 

## Usage
This can be used to bolster existing authentication security, for example having a requirement to use guard key on every third login. I've included a example php intergration, but this can easily be adapted for c#, python, c++ etc. 

## Example and project
There is included a php example of implimenting server side, and an uncompliled version of the c# windows program. This will need compiling in visual studio, however there is a working ready to go version located in the bin directory. Because this project does not come with a signed certificate you will either have to set an exemption on the systems you are using or create a self-signed certificate for use on local systems. 

## Disclaimer 
This software comes as is, and the author accepts no responsiblity for lose, damage or data breach as a result of this software's use. Please ensure whenever you modify or change an authentication process you carefully consider all aspects of security and employ a qualified security advisor to stress and pen test a system.
