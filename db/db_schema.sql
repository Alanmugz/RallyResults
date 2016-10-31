--amulligan 30/10/2016

--DROP TABLE "Event"
CREATE TABLE "Event"
(
	"Id" integer NOT NULL,
	"Category_Class" json,
	"CreationTimestamp" TIMESTAMP  NOT NULL,
	CONSTRAINT "PK_CategoryClass" PRIMARY KEY ("Id")
)
--DELETE FROM "Event"

--DROP TYPE stage
create type stage as (
    Stage_Name        text,
    Stage_Distance    decimal,
    Stage_Start_Time  timestamp
);

--DROP TABLE "Event_Category"
CREATE TABLE "Event_Category"(
    "Id" serial NOT NULL,
	"CategoryType" text NOT NULL,
    "Stage_information" stage[],
    "Total_stage_km" double precision,
	"Offset" integer,
    CONSTRAINT "PK_Event_Id_CategoryType" PRIMARY KEY ("Id", "CategoryType"),
	FOREIGN KEY ("Id") REFERENCES "Event" ("Id")
)
--DELETE FROM "Event_Category"

--DROP TABLE "Entrant"
CREATE TABLE "Entrant"
(
  "Id" integer NOT NULL,
  "Number" integer NOT NULL,
  "Driver" text,
  "CoDriver" text,
  "Address" text,
  "Car" text,
  "Class" text,
  "Category" text,
  "StageData" double precision[],
  "SuperRally" boolean,
  CONSTRAINT "PK_Entrant_Id_Number" PRIMARY KEY ("Id", "Number")
)
--DELETE TABLE "ENtrant"