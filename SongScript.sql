SELECT * FROM ntn2tkrm3kwxdpc0.songs;

-- drop database ntn2tkrm3kwxdpc0;

use ntn2tkrm3kwxdpc0;

create database ntn2tkrm3kwxdpc0;

create table songs(
id int not null auto_increment,
title text,
dateadded datetime,
isdeleted text,
isfavorited text,
primary key (id)
);

INSERT INTO songs (title, dateAdded, isDeleted, isfavorited) VALUES ('NEW SONG', current_timestamp, 'n', 'y');

INSERT INTO songs (title, dateAdded, isDeleted, isfavorited) VALUES ('TEST SONG', current_timestamp, 'n', 'n');

INSERT INTO songs (title, dateAdded, isDeleted, isfavorited) VALUES ('Mr. Brightside', current_timestamp, 'n', 'n');

INSERT INTO songs (title, dateAdded, isDeleted, isfavorited) VALUES ('Thunderstruck', current_timestamp, 'n', 'n');

INSERT INTO songs (title, dateAdded, isDeleted, isfavorited) VALUES ('Yeah Alabama!', current_timestamp, 'n', 'n');

INSERT INTO songs (title, dateAdded, isDeleted, isfavorited) VALUES ('Friends In Low Places', current_timestamp, 'n', 'n');

INSERT INTO songs (title, dateAdded, isDeleted, isfavorited) VALUES ('Dixieland Delight', current_timestamp, 'n', 'y');

INSERT INTO songs (title, dateAdded, isDeleted, isfavorited) VALUES ('Sweet Home Alabama', current_timestamp, 'n', 'y');

