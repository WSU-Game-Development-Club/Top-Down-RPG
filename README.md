# Top-Down-RPG
WSU Game Development's Club first project!

Unity Version: 2022.3.31f1

## Git Guides
[How to Add Project to Your Device from GitHub](#how-to-add-project-to-your-device-from-github)

[How to Manage Branches](#how-to-manage-branches)

[How to Push and Pull](#how-to-push-add-your-changes-and-pull-update-your-project)

[Push Yourself!](#push-yourself)

# How to Add Project to Your Device from GitHub
<ol>
  <li>Install <a href = https://git-scm.com/downloads>Git</a> if you haven't already</li>
  <li>Copy the project by selecting "<> Code" at the top of the page and Copy the link displayed</li>
  <li>Search your device for "Git Bash" and open it</li>
  <li>Type in <kbd>git clone (link)</kbd> and use the link you copied</li>
  <li>Type <kbd>ls</kbd> to see where the folder has been placed (it is most likely in the Users folder on your device)</li>
    <ul>
      <li>Feel free to move the folder to wherever you like</li>
    </ul>
  <li>Open Unity Hub and select "Add" from the projects menu</li>
  <li>Find the Topdown_RPG file and open until you get to the folder with the assets, packages, etc. and select "Open"</li>
  <li>You should now have the project's main branch avaliable to open in the Unity Editor</li>
</ol>
After this, your project may not have the desired code or assets

See [How to Manage Branches](#how-to-manage-branches) to fix this

# How to Manage Branches
<ol>
  <li>Open Git Bash and navigate to the project directory</li>
  <ul>
    <li>If you do not know how to traverse directories to get to your project, use <a href = https://support.cs.wm.edu/index.php/tips-and-tricks/basic-linux-commands>this resource</a> for guidance</li>
    <li>You will mainly be using <kbd>cd</kbd> and <kbd>ls</kbd></li>
  </ul>
  <li>Use <kbd>git branch -a</kbd> to list all of the project's branches</li>
  <li>To work on a branch, add it to your device and switch to it by using <kbd>git checkout (branch name)</kbd></li>
  <ul>
    <li>Sometimes, there may be conflicts. Git will tell you what files are conflicting and how to fix it</li>
  </ul>
  <li>Your Unity project should now have the branch's data</li>
</ol>

# How to Push (Add Your Changes) and Pull (Update Your Project)
## To Pull
<ul>
  <li>Pulling should be done at the beginning of every project work session so you are up to date</li>
</ul>
<ol>
  <li>Navigate to the desired branch you'd like to work on</li>
  <li>Use <kbd>git status</kbd> to see if your project is not up to date</li>
  <li>Use <kbd>git pull</kbd></li>
  <li>Your project should now be updated</li>
</ol>

## To Push
<ul>
  <li>Should be done when a functional feature/modification has been completed</li>
</ul>
<ol>
  <li>Navigate to the desired branch you'd like to push to (the branch you pulled from)</li>
  <li>Use <kbd>git status</kbd> to see what you have modified/added</li>
  <li>Use <kbd>git add (file name)</kbd> to add modified/added work</li>
  <li>Use <kbd>git commit -m "(commit description)"</kbd> to commit the changes you've added to your local branch</li>
  <li>Use <kbd>git push</kbd> to push your changes to the branch in GitHub</li>
</ol>

# Push Yourself
Use the skills you've learned to:
<ol>
  <li>Copy the project to your device</li>
  <li>Modify <samp>push_yourself.txt</samp> using vim or notepad to include your name, date, and project you're working on</li>
  <li>Add, commit and push your changes</li>
</ol>
Congratulations! You're on your way to becoming a Git pro.
