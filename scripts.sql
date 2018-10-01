CREATE TABLE "Cars"(
	"Id" SERIAL Primary Key,
	"Name" Text,
	"Make" Text,
	"Year" Text,
	"Model" Text
);

-- STORE 
CREATE OR REPLACE FUNCTION "storeCar"(
	"name" text,
	"make" text,
	"year" text,
	"model" text)
RETURNS integer
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE 
AS $BODY$

DECLARE "carId" INTEGER;
BEGIN
	INSERT INTO "Cars"("Name", "Make", "Year", "Model")
	VALUES("name", "make", "year", "model")
	RETURNING "Id" INTO "carId";
	IF "carId" > 0 THEN 
		RETURN "carId";
	END IF;
END
$BODY$;

--DELETE
CREATE OR REPLACE FUNCTION "deleteCar"("id" integer)
RETURNS integer
	LANGUAGE 'plpgsql'
	COST 100
	VOLATILE
AS $BODY$
DECLARE "carId" integer;
BEGIN
	DELETE FROM "Cars"
	WHERE "Id" = "id"
	RETURNING "Id" INTO "carId";
	RETURN "carId";
END
$BODY$

-- ALL CARS
CREATE OR REPLACE FUNCTION "getCars"()
RETURNS SETOF "Cars"
	LANGUAGE 'plpgsql'
    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$
BEGIN
	RETURN QUERY
	SELECT "Id", "Name", "Make", "Year", "Model"
	FROM "Cars";
END
$BODY$

-- ONE CAR
CREATE OR REPLACE FUNCTION "getCar"("id" integer)
RETURNS TABLE("Id" integer, "Name" text, "Make" text, "Year" text, "Model" text)
	LANGUAGE 'plpgsql'
    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$
BEGIN
    RETURN QUERY
	SELECT "Cars"."Id", "Cars"."Name", "Cars"."Make", "Cars"."Year", "Cars"."Model"
	FROM "Cars" 
	WHERE "Cars"."Id" = "id";
END
$BODY$

-- UPDATE
CREATE OR REPLACE FUNCTION "updateCar"("id" integer, "name" text, "make" text, "year" text, "model" text)
RETURNS integer
LANGUAGE 'plpgsql'
    COST 100
    VOLATILE 
AS $BODY$
	DECLARE "carId" integer;
	BEGIN
		UPDATE "Cars"
		SET "Name" = "name", 
		"Make" = "make", 
		"Year" = "year", 
		"Model" = "model"
		WHERE "Cars"."Id" = "id"
		RETURNING "Cars"."Id" INTO "carId";
		RETURN "carId";
	END
$BODY$


