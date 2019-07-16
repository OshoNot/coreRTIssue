CREATE TABLE map (
   name VARCHAR (50) UNIQUE NOT NULL,
   value VARCHAR (50) NOT NULL
);

INSERT INTO map (name, value)
VALUES
    ('foo', 'bar'),
    ('wo', 'lo');
