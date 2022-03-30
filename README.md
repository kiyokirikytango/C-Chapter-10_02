C#-Chapter-10_02

Previously, you created a Mural class for Marshall’s Murals. The class holds a customer’s name, a mural code, and a description. Now, add a field named Price to the Mural class that holds a price.

Now, extend the Mural class in your code to create subclasses named InteriorMural and ExteriorMural, and place statements that determine a mural’s price within these classes. (A mural’s price depends on the month, as described in the case problem in Chapter 9 of your book.)

The constructor for the subclasses should have one parameter for the month the mural is scheduled.

Also create ToString() methods for these subclasses that return a string containing all the pertinent data for a mural. The string should be returned in the following format (shown for one exterior and one interior mural):

Exterior, Seascape mural for Customer: Steve  Price $699.00
Interior, Landscape mural for Customer: Joe  Price $500.00
