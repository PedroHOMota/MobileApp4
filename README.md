
Unity Project (UWP) for Mobile Application Development 3 Module (4th Year, Bsc (Hons) in Software Development) 

## Download It Here!

This game can be downloaded on [windows store]()
* **Release Build**: [Alpha-1.0](https://tinyurl.com/yaeh24yn)

## How to play

The game can be played with either mouse and keyboard or xbox 360 controller

| Key      |  Action |
| ---      | ---       |
| WASD         |  Movement  |
| Rigth-click         |  Shoot  |

| Left-Analog         |  Movement| 
| A     |  Shoot |


## Architecture

The client was built on Unity using c# and later convert to UWP. 

The server consists of a flask API and a MySQL server as a database. The api accepts get and post requests. POST is used to upload a new user score and GET to retriver in JSON format the top 10 highest scores.


## Repo Structure

The following is how this repository is structured:

* **OkamiBushi**: Contains the Unity Project.
    * **Assets**: Contains scripts, Animation controllers, game sceenes and Graphics and models.
* **UWP**:  Contains the UWP project compiled by Unity.


## Tools

* [Unity](https://unity3d.com/)
* Visual Studio 2017 [Community Edition](https://www.visualstudio.com/downloads/)


## Deployment

The server is currently and database are deployed in the cloud using [PythonAnywhere](https://www.pythonanywhere.com). The client side is compiled and ready to install trought the store or on the (link)[] 

## Authors

* **Pedro Mota** - *Development* 


## Acknowledgments, References and Assets

Most of assests used in this project are taken from the unity.
