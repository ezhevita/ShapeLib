CREATE TABLE categories
(
    id   int IDENTITY
        CONSTRAINT categories_pk PRIMARY KEY NONCLUSTERED,
    name varchar(100) NOT NULL
)

create table products
(
    id   int IDENTITY
        CONSTRAINT products_pk PRIMARY KEY NONCLUSTERED,
    name varchar(100) NOT NULL
)

create table categories_products
(
    product_id  int NOT NULL
        CONSTRAINT categories_products_products_id_fk REFERENCES products,
    category_id int NOT NULL
        CONSTRAINT categories_products_categories_id_fk REFERENCES categories,
    CONSTRAINT categories_products_pk
        PRIMARY KEY NONCLUSTERED (product_id, category_id)
)

INSERT INTO products (name) VALUES ('test1'),
                                   ('test2'),
                                   ('test3');

INSERT INTO categories (name) VALUES ('test_c1'),
                                     ('test_c2');

INSERT INTO categories_products (product_id, category_id) VALUES (2, 1),
                                                                 (2, 2),
                                                                 (3, 1);

SELECT products.name   AS product_name,
       categories.name AS category_name
FROM products
         LEFT JOIN categories_products on products.id = categories_products.product_id
         LEFT JOIN categories on categories_products.category_id = categories.id