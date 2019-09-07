#set the Routines folder path of HearthBuddy
$targetPath = "C:\Users\clu\Desktop\GitHub\HearthbuddyRelease\Routines"

#create the target folder if not exists
$flag = Test-Path $targetPath
if(!$flag)
{
	Write-Host "Default routine folder $targetPath not exist"
	Break
}

#delete all files under target folder, but the empty subfolders will be kept
#https://superuser.com/a/741968
Get-ChildItem -Path $targetPath -Include *.* -Recurse | foreach { $_.Delete()}

Copy-Item -Path DefaultRoutine -Destination $targetPath -recurse -Force

Write-Host "Finished"