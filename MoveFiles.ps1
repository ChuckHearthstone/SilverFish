#set the target folder path
#the path must end with \
$targetPath = "C:\HearthBuddy\Routines\"

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

Copy-Item -Path DefaultRoutine -Destination $newTargetPath -recurse -Force

Write-Host "Finished"