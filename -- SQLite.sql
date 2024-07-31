-- SQLite
CREATE TABLE Client
(
    ID integer PRIMARY KEY,
    ClientName text null,
    Residency text null
);

INSERT INTO Client
    (ClientName, Residency)
VALUES
    ('John Nico', 'Bungtod'),
    ('John Dhaniel', 'Pelaez'),
    ('John Brent', 'Taytayan')

SELECT *
FROM Client