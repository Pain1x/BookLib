CREATE TRIGGER tr_AuthorsINSERTorUPDATE ON Authors
AFTER UPDATE,INSERT
AS 
UPDATE Authors
SET Name = UPPER(LEFT(Name, 1)) + LOWER(SUBSTRING(Name ,2, LEN(Name)))
WHERE ID = (SELECT ID FROM inserted)