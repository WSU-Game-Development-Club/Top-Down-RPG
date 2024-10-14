# Top-Down-RPG
WSU Game Development's Club first project!

Unity Version: 2022.3.31f1

## Git Guides
[How to Add Project to Your Device from GitHub](#how-to-add-project-to-your-device-from-github)

[How to Manage Branches](#how-to-manage-branches)

[How to Push and Pull](#how-to-push-add-your-changes-and-pull-update-your-project)

# How to Add Project to Your Device from GitHub
<ol>
  <li>Install <a href = https://git-scm.com/downloads>Git</a> if you haven't already</li>
  <li>Copy the project by selecting "<> Code" at the top of the page and Copy the link displayed</li>
  <li>Search your device for "Git Bash" and open it</li>
  <li>Type in <font face = "Comic sans MS">git clone and use the link you copied</li>
  <li>Type "ls" to see where the folder has been placed (it is most likely in the Users folder on your device)</li>
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
    <li>You will mainly be using cd and ls</li>
  </ul>
  <li>Use "git branch -a" to list all of the project's branches</li>
  <li>To work on a branch, add it to your device by using "git fetch origin (branch name)"</li>
  <li>Next, switch to the branch using "git switch (branch name)" (no need to include origin this time)</li>
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
<ol></ol>
