# GHLearning-EasyUnitOfWork

[![.NET](https://github.com/gordon-hung/GHLearning-EasyUnitOfWork/actions/workflows/dotnet.yml/badge.svg)](https://github.com/gordon-hung/GHLearning-EasyUnitOfWork/actions/workflows/dotnet.yml)

[![Ask DeepWiki](https://deepwiki.com/badge.svg)](https://deepwiki.com/gordon-hung/GHLearning-EasyUnitOfWork)

Unit of Work is the concept related to the effective implementation of the Repository Pattern. To understand this concept in better it is important to understand the concept of the Repository Pattern. We will not get into the details of the Repository Pattern in this discussion. But a small idea of this concept is necessary to proceed further.

## The Repository Pattern

A repository is nothing but a class defined for an entity, with all the operations possible on that specific entity. For example, a repository for an entity Customer, will have basic CRUD operations and any other possible operations related to it. A Repository Pattern can be implemented in Following ways:

* **One repository per entity (non-generic) :** This type of implementation involves the use of one repository class for each entity. For example, if you have two entities Order and Customer, each entity will have its own repository.
* **Generic repository:** A generic repository is the one that can be used for all the entities, in other words it can be either used for Order or Customer or any other entity.

## Unit of Work in the Repository Pattern

Unit of Work is referred to as a single transaction that involves multiple operations of insert/update/delete and so on kinds. To say it in simple words, it means that for a specific user action (say registration on a website), all the transactions like insert/update/delete and so on are done in one single transaction, rather then doing multiple database transactions. This means, one unit of work here involves insert/update/delete operations, all in one single transaction.
