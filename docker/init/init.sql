-- Initialize database
CREATE DATABASE todosdb;
\c tododb
CREATE TABLE IF NOT EXISTS todos (
    ID uuid PRIMARY KEY DEFAULT gen_random_uuid() NOT NULL,
    TaskDescription TEXT NOT NULL,
    CreatedAt timestamptz NOT NULL,
    DueDate timestamptz NOT NULL,
    Completed BOOLEAN NOT NULL
)