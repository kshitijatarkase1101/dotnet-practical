using System;
using System.Collections.Generic;

public class CategoryManager
{
    List<Category> categories = new List<Category>()
    {
        new Category{ CategoryId = 1, CategoryName = "Electronics"},
        new Category{ CategoryId = 2, CategoryName = "Books"},
        new Category{ CategoryId = 3, CategoryName = "Groceries"},
        new Category{ CategoryId = 4, CategoryName = "Fashion"},
        new Category{ CategoryId = 5, CategoryName = "Sports"},
        new Category{ CategoryId = 6, CategoryName = "Furniture"}
    };

    // Add Category
    public void AddCategory()
    {
        Category category = new Category();

        Console.Write("Enter Category ID : ");
        category.CategoryId = Convert.ToInt32(Console.ReadLine());

        foreach (Category c in categories)
        {
            if (c.CategoryId == category.CategoryId)
            {
                Console.WriteLine("Category already exists.");
                return;
            }
        }

        Console.Write("Enter Category Name : ");
        category.CategoryName = Console.ReadLine();

        categories.Add(category);

        Console.WriteLine("Category Added Successfully.");
    }

    // Delete Category
    public void DeleteCategory()
    {
        Console.Write("Enter Category ID : ");
        int id = Convert.ToInt32(Console.ReadLine());

        Category category = null;

        foreach (Category c in categories)
        {
            if (c.CategoryId == id)
            {
                category = c;
                break;
            }
        }

        if (category != null)
        {
            categories.Remove(category);
            Console.WriteLine("Category Deleted Successfully.");
        }
        else
        {
            Console.WriteLine("Category Not Found.");
        }
    }

    // Update Category
    public void UpdateCategory()
    {
        Console.Write("Enter Category ID : ");
        int id = Convert.ToInt32(Console.ReadLine());

        Category category = null;

        foreach (Category c in categories)
        {
            if (c.CategoryId == id)
            {
                category = c;
                break;
            }
        }

        if (category == null)
        {
            Console.WriteLine("Category Not Found.");
            return;
        }

        Console.Write("Enter New Category Name : ");
        category.CategoryName = Console.ReadLine();

        Console.WriteLine("Category Updated Successfully.");
    }

    // View Categories
    public void ViewCategories()
    {
        if (categories.Count == 0)
        {
            Console.WriteLine("No Categories Available.");
            return;
        }

        foreach (Category c in categories)
        {
            Console.WriteLine(c.CategoryId + " - " + c.CategoryName);
        }
    }

    // Search Category
    public Category SearchCategory(int id)
    {
        foreach (Category c in categories)
        {
            if (c.CategoryId == id)
            {
                return c;
            }
        }

        return null;
    }

    // Return Category List
    public List<Category> GetCategories()
    {
        return categories;
    }
}