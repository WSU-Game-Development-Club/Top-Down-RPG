# Top-Down-RPG
WSU Game Development's Club first project!

Unity Version: 2022.3.31f1

## Programming Conventions

Use camelCase for all member variables

Use PascalCase for all methods and properties

All member variables must be `private`, using properties for public access

Use `[SerializeField]` to make private members accessible by the Unity editor

Comment your code! In addition to describing the function of the code, sign your name so other's know who to contact with questions about it

Every method must have a comment header. They follow the form of the example below:

    /// <summary>
    /// Some function description
    /// </summary>
    /// <param name="x">some parameter description</param>
    /// <param name="y">some parameter description</param>
    /// <returns>return description</returns>
    private int FooBar(int x, int y)
    {
        return 0;
    }
