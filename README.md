# SwaggerCRUDWebAPI

This is a basic ASP.NET Core WebAPI which is talking to SQL express database with CRUD operations.


# How I forked the GitHub Repo steps

### Step 1: Create a local shallow clone of the source repository 
````
git clone --depth 1 https://github.com/dotnetmirror/CRUDASPNETCoreWebAPI
````
The --depth 1 flag creates a shallow clone, which only includes the single most recent commit, effectively removing all prior history locally


### Step 2: Remove the old Git history and reinitialize Git 
Navigate into the newly cloned directory and remove the existing .git folder (which contains the limited history) to prepare for a fresh start. 
````
cd [repository_name]
rmdir /s /q .git 
git init
````
### Step3 : Add all files and commit them as the initial commit 
````
git add .
git commit -m "Initial commit of project files"
````

### Step4 : push an existing repository from the command line
````
git remote add origin https://github.com/dotnetmirror/SwaggerCRUDWebAPI.git
git branch -M main
git push -u origin main
````
### Step5 - renamed all CRUDASPNETCoreWebAPI to SwaggerCRUDWebAPI
