# Parking Lot Management System

## About
Our app uses an already-existing repo on github to detect license plate from customers. For more information, check [Requirements and setup](#requirements-and-setup)

* Check whether a vehicle is allowed to go in or not.
* Compute fee and give information about the vehicle going out of the parking lot.
* Parking lot information: empty lots for new vehicles.
* Statistical information: current number of parked vehicles, week revenue, month revenue

## Requirements and setup
The main app: This repo was built on Visual Studio 2022 (for reproducible result, please install all the below dependancies).
- AForge
- AForge.Imaging
- AForge.Math
- AForge.NetStandard
- AForge.Video
- AForge.Video.DirectShow
- EntityFramework
- Guna.UI2.WinForms
- Microsoft.CSharp
- pythonnet
- ReaLTaiizor
- Stub.System.Data.SQLite.Core.NetFramework
- System.Data.SQLite
- System.Data.SQLite.Core
- System.Data.SQLite.EF6
- System.Data.SQLite.Linq
- System.Reflection.Emit

License plate detector (yolo server): Check out this repo https://github.com/ltgbao04/yolo_server.git.


## Usage
Make sure the server is ready before clicking the `Start` button on Visual Studio 2022.