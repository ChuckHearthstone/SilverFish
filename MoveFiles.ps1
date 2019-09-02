#set the target folder path
#the path must end with \
$targetPath = "C:\HearthBuddy\SilverFish\"
#$targetPath

#create the target folder if not exists
$flag = Test-Path $targetPath
if(!$flag)
{
	Write-Host "Default routine folder $targetPath not exist"
	Break
}

#delete all files under target folder, but the subfolders will be kept
#https://superuser.com/a/741968
Get-ChildItem -Path $targetPath -Include *.* -Recurse | foreach { $_.Delete()}


Copy-Item -Path DefaultRoutine.cs -Destination $targetPath
Copy-Item -Path DefaultRoutineSettings.cs -Destination $targetPath
Copy-Item -Path SilverFishBot.cs -Destination $targetPath
Copy-Item -Path SettingsGui.xaml -Destination $targetPath

Copy-Item -Path .\SilverFish\ai -Destination $targetPath -recurse -Force
Copy-Item -Path .\SilverFish\behavior -Destination $targetPath -recurse -Force
Copy-Item -Path .\SilverFish\cards -Destination $targetPath -recurse -Force
Copy-Item -Path .\SilverFish\data -Destination $targetPath -recurse -Force
Copy-Item -Path .\SilverFish\Helpers -Destination $targetPath -recurse -Force
Copy-Item -Path .\SilverFish\penalties -Destination $targetPath -recurse -Force