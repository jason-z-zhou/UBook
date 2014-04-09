/*==============================================================*/
/* DBMS name:      MySQL 5.0                                    */
/* Created on:     2011-6-14 17:00:22                           */
/*==============================================================*/

drop database if exists onlinebook;

create database onlinebook;

use onlinebook;

drop table if exists book;

drop table if exists category;

drop table if exists creditCard;

drop table if exists orderitem;

drop table if exists publisher;

drop table if exists shippingInfo;

drop table if exists user;

drop table if exists userOrder;

/*==============================================================*/
/* Table: book                                                  */
/*==============================================================*/
create table book
(
   isbn                 varchar(20) not null,
   cid                  int(8),
   pname                varchar(30),
   author               varchar(80),
   name                 varchar(200),
   edition              varchar(8),
   dateofpublication    date,
   price                double not null,
   description          varchar(4000),
   pictureName          varchar(40),
   primary key (isbn)
);

/*==============================================================*/
/* Table: category                                              */
/*==============================================================*/
create table category
(
   id                   int(8) not null,
   name                 varchar(100),
   primary key (id)
);

/*==============================================================*/
/* Table: creditCard                                            */
/*==============================================================*/
create table creditCard
(
   cardNum              varchar(20) not null,
   username             varchar(100),
   nameOnCard           varchar(80) not null,
   type                 varchar(20) not null,
   expirationDate       date not null,
   primary key (cardNum)
);

/*==============================================================*/
/* Table: orderitem                                             */
/*==============================================================*/
create table orderitem
(
   id                   int not null auto_increment,
   isbn                 varchar(20),
   oid                  varchar(30),
   qty                  int not null,
   primary key (id)
);

/*==============================================================*/
/* Table: publisher                                             */
/*==============================================================*/
create table publisher
(
   name                 varchar(150) not null,
   address              varchar(400),
   primary key (name)
);

/*==============================================================*/
/* Table: shippingInfo                                          */
/*==============================================================*/
create table shippingInfo
(
   id                   varchar(30) not null,
   address              varchar(500) not null,
   phone                varchar(20),
   zipCode              varchar(10),
   method               varchar(20) not null,
   recipientName        varchar(80) not null,
   primary key (id)
);

/*==============================================================*/
/* Table: user                                                  */
/*==============================================================*/
create table user
(
   username             varchar(100) not null,
   password             varchar(100) not null,
   email                varchar(80),
   realname             varchar(80) not null,
   address              varchar(400) not null,
   zipCode              varchar(10),
   phone                varchar(15),
   primary key (username)
);

/*==============================================================*/
/* Table: userOrder                                             */
/*==============================================================*/
create table userOrder
(
   id                   varchar(30) not null,
   username             varchar(10),
   cardNum              varchar(20),
   sid                  varchar(30),
   date                 date not null,
   primary key (id)
);

alter table book add constraint FK_Reference_1 foreign key (cid)
      references category (id) on delete restrict on update restrict;

alter table book add constraint FK_Reference_2 foreign key (pname)
      references publisher (name) on delete restrict on update restrict;

alter table creditCard add constraint FK_Reference_6 foreign key (username)
      references user (username) on delete restrict on update restrict;

alter table orderitem add constraint FK_Reference_8 foreign key (oid)
      references userOrder (id) on delete restrict on update restrict;

alter table orderitem add constraint FK_Reference_9 foreign key (isbn)
      references book (isbn) on delete restrict on update restrict;

alter table userOrder add constraint FK_Reference_10 foreign key (sid)
      references shippingInfo (id) on delete restrict on update restrict;

alter table userOrder add constraint FK_Reference_4 foreign key (username)
      references user (username) on delete restrict on update restrict;

alter table userOrder add constraint FK_Reference_7 foreign key (cardNum)
      references creditCard (cardNum) on delete restrict on update restrict;

