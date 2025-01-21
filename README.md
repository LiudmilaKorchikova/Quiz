A quiz displayed in a Windows Forms application.

Each question has four answer options.
At the start, the player is asked to enter a name; if no name is entered, the player is assigned the default name "anonym."
Questions and answers are stored in a .txt file, loaded into the application, and presented in random order, with answer options also randomized.
The game history stores the last 15 games, including the player's name, result, date, and time of attempt.
The history is serialized and deserialized to/from an XML file.
