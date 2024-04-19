using System;
using System.Collections.Generic;
using System.Linq;

public class Dish
{
    public string Name { get; set; }
    public double Calories { get; set; }
    public double[] Bju { get; set; } // массив [белки, жиры, углеводы]

    public Dish(string name, double calories, double[] bju)
    {
        Name = name;
        Calories = calories;
        Bju = bju;
    }
}
// Методы расширения для работы с коллекциями блюд
public static class DishExtensions
{
    public static IEnumerable<Dish> TopCarbohydrateDishes(this List<Dish> dishes, int count = 3)
    {
        return dishes.OrderByDescending(dish => dish.Bju[2]).Take(count);
    }
}

// Класс для списка блюд
public class DishList : List<Dish>
{
    public DishList() : base() { }

    public void PrintTopCarbohydrateDishes()
    {
        var topDishes = this.TopCarbohydrateDishes();
        Console.WriteLine("Top Carbohydrate Dishes:");
        foreach (var dish in topDishes)
        {
            Console.WriteLine($"{dish.Name} - Carbs: {dish.Bju[2]} g per 100g");
        }
    }
}

public class Program
{
    public static void Main()
    {
        // Создаем список блюд и инициализируем его
        var dishes = new DishList
        {
            new Dish("Spaghetti Carbonara", 320, new double[] {12, 15, 31}),
            new Dish("Caesar Salad", 250, new double[] {5, 20, 12}),
            new Dish("Chicken Curry", 415, new double[] {25, 15, 18}),
            new Dish("Beef Stroganoff", 400, new double[] {30, 25, 10}),
            new Dish("Chocolate Cake", 360, new double[] {4, 25, 40})
        };

        // Выводим на экран три блюда с наибольшим содержанием углеводов
        dishes.PrintTopCarbohydrateDishes();
    }
}