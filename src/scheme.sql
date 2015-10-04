CREATE TABLE todo (
   id serial,
   created timestamp DEFAULT now() NOT NULL,
   message text NOT NULL
);