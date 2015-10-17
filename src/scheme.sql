CREATE TABLE todo (
   id serial,
   created timestamp with time zone DEFAULT now() NOT NULL,
   message text NOT NULL
);