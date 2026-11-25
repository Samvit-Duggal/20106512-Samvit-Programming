
CREATE TABLE members (
    registration_no SERIAL PRIMARY KEY,
    full_name VARCHAR(100) NOT NULL,
    address TEXT NOT NULL,
    contact_no VARCHAR(20) NOT NULL,
    email VARCHAR(150) NOT NULL,
    duration INT NOT NULL CHECK (duration IN (6, 12))
);

ALTER SEQUENCE members_registration_no_seq
RESTART WITH 1001;
