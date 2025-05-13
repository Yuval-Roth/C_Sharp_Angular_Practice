create table if not exists comments (
    id serial primary key,
    content text not null,
    timestamp text not null
);