#!/bin/bash
#Add the dotnet path to the path
export PATH="$HOME/.dotnet":$PATH

dotnet restore


cd src/Host
dotnet build -c Debug
dotnet run

read -s -n 1 -p "Press any key to continue . . ."
echo ""