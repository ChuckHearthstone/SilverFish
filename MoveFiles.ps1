#set the target folder path
#the path must end with \
$targetPath = "C:\HearthBuddy\Routines\DefaultRoutine"

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

$newTargetPath = Join-Path -Path $targetPath -ChildPath "SilverFish\ai"
Copy-Item -Path .\SilverFish\ai -Destination $newTargetPath -recurse -Force

$newTargetPath = Join-Path -Path $targetPath -ChildPath "SilverFish\behavior"
Copy-Item -Path .\SilverFish\behavior -Destination $newTargetPath -recurse -Force

$newTargetPath = Join-Path -Path $targetPath -ChildPath "SilverFish\cards"
Copy-Item -Path .\SilverFish\cards -Destination $newTargetPath -recurse -Force

$newTargetPath = Join-Path -Path $targetPath -ChildPath "SilverFish\data"
Copy-Item -Path .\SilverFish\data -Destination $newTargetPath -recurse -Force

$newTargetPath = Join-Path -Path $targetPath -ChildPath "SilverFish\Helpers"
Copy-Item -Path .\SilverFish\Helpers -Destination $newTargetPath -recurse -Force

$newTargetPath = Join-Path -Path $targetPath -ChildPath "SilverFish\penalties"
Copy-Item -Path .\SilverFish\penalties -Destination $newTargetPath -recurse -Force

Write-Host "Finished"