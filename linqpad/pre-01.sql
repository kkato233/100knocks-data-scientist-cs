-- SQLite で テーブルを作成する。

-- drop table if exists category;
-- drop table if exists customer;
-- drop table if exists geocode;
-- drop table if exists product;
-- drop table if exists receipt;
-- drop table if exists store;

create table category (
    category_major_cd text,
    category_major_name text,
    category_medium_cd text,
    category_medium_name text,
    category_small_cd text primary key,
    category_small_name text
);

create table customer (
    customer_id text primary key,
    customer_name text,
    gender_cd text,
    gender text,
    birth_day text,
    age integer,
    postal_cd text,
    address text,
    application_store_cd text,
    application_date text,
    status_cd text
);

create table geocode (
    id integer primary key autoincrement,
    postal_cd text,
    prefecture text,
    city text,
    town text,
    street text,
    address text,
    full_address text,
    longitude real,
    latitude real
);

create table product (
    product_cd text,
    category_major_cd text,
    category_medium_cd text,
    category_small_cd text references category(category_small_cd),
    unit_price integer,
    unit_cost integer
);

CREATE INDEX [IFK_PRODUCT_CATEGORY_SMALL_ID] ON [product] ([category_small_cd])

create table store (
    store_cd text primary key,
    store_name text,
    prefecture_cd text,
    prefecture text,
    address text,
    address_kana text,
    tel_no text,
    longitude real,
    latitude real,
    floor_area real
);

create table receipt (
    sales_ymd text,
    sales_epoch integer,
    store_cd text references store(store_cd),
    receipt_no integer,
    receipt_sub_no integer,
    customer_id text references customer(customer_id),
    product_cd text references product(product_cd),
    quantity integer,
    amount integer
);
CREATE INDEX [IFK_PRODUCT_CATEGORY_SMALL_ID] ON [product] ([category_small_cd])
CREATE INDEX [IFK_RECEIPT_CUSTOMER_ID] ON [receipt] ([customer_id])
CREATE INDEX [IFK_RECEIPT_PRODUCT_CD] ON [receipt] ([product_cd])
CREATE INDEX [IFK_RECEIPT_STORE_CD] ON [receipt] ([store_cd])