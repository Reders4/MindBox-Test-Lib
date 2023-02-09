SELECT p.Name, c.Name
FROM Categories AS c 

JOIN ProductsCategories AS pc 
ON c.CategoriesID = pc.CategoriesID

RIGHT JOIN Products AS p 
ON p.ProductID = pc.ProductID

ORDER BY p.Name
