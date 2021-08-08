SELECT products.name   AS product_name,
       categories.name AS category_name
FROM products
         LEFT JOIN categories_products on products.id = categories_products.product_id
         LEFT JOIN categories on categories_products.category_id = categories.id