# PromotionEngine

## User Requirement

Create a Promotion Engine app which will apply a given promotions on top of a cart and returns the total amount of all products in cart

### User Scenarios:
Unit price for SKU IDs
A      50
B      30
C      20
D      15

Active Promotions
3 of A's for 130
2 of B's for 45
C & D for 30

Scenario A
1 * A     50
1 * B     30
1 * C     20
======
Total     100

Scenario B
5 * A     130 + 2*50
5 * B     45 + 45 + 30
1 * C     20
======
Total     370

Scenario C
3 * A     130
5 * B     45 + 45 + 1 * 30
1 * C     -
1 * D     30
======
Total     280

## Design Approach

To follow the clean architecture pattern, I have chosen DDD with CQRS. There are mainly 4 Application layers in the solution.

##### Application

Application layers has all the mainly contains cart behaviours, interfaces, CQORS commands and quires.

We will be raising a GetCartTotalAfterPromotionsQuery from web api controller which will get handled in the GetCartTotalAfterPromotionsQuery.cs.

GetCartTotalAfterPromotionsQuery will receive the current cart ID and will apply the cart behaviour on that cart. CartBehaviour is responsible for getting the cart then run the

Promotion Engine on top of the cart. In addition to this Application layer contains all the api layer exceptions, service registrations etc

##### Domain

Domain contains all the Bounded contexts and all the Domain related classes

##### Infrastructure

###### Infrastructure.Shared

This layer contains all the sahred concerns across the infra. This layer is to demostrate the spliting of infrastructure. Current application is not using the shared

###### Infrastructure.Persistence

This layer contains all the logic to connect to database  and all logic for CURD operations. I am using the generic repository pattern with the help fo EF core

We have a generic repository with individual repository specific for entities . For debugging purpose we are using in memory database

#### Web api

I am using .net core 3.1 web api for this project. Also we have added swagger doc and ui for easy testing of the application.

## How to run.

###### Git clone https://github.com/ohm12341/PromotionEngine.git
###### Open  PromotionEngine\PE.Solution in VS studio 2019
###### Run Build
###### Select WebApi as start up project
###### Run project- this will open swagger UI
###### Click on /api/v{version}/Cart/{Id}/Promotions Get Method in swagger UI
###### Click Tryout

###### Enter parameters:
###### version as 1 always
###### Id(Cart ID) : 1 or 2 or 3

###### Click Execute



