CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS listings(
        id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name VARCHAR(255) NOT NULL,
        description VARCHAR(500) NOT NULL,
        img VARCHAR(1000) NOT NULL,
        price INT NOT NULL,
        category CHAR(255) NOT NULL,
        creatorId CHAR(255) NOT NULL,
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

SELECT * FROM listings

SELECT * FROM accounts

INSERT INTO
    listings(
        name,
        description,
        img,
        price,
        category,
        creatorId
    )
VALUES (
        "Sequin Skirt",
        "Take it to a new level this holiday.",
        "https://i.pinimg.com/564x/fd/0b/ef/fd0bef3b92bf50a3b17272f68679e50b.jpg",
        50,
        "formal",
        "652ef49aff9881f8395eb350"
    );

DROP TABLE listings