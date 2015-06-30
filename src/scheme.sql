CREATE TABLE "Todo" (
	"Id" serial,
	"Created" timestamp DEFAULT now() NOT NULL,
	"Message" text NOT NULL
);