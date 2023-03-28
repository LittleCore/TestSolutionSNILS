CREATE TABLE RandomDataBase
(snils_number varchar(14) not null,
 snils_result number not null);
 
INSERT INTO RandomDataBase VALUES
    ('111-222-333 44', 0);
    
INSERT INTO RandomDataBase VALUES
    ('662-457-742 22', 1);

CREATE OR REPLACE TRIGGER CHECKSNILSTRIGGER
AFTER INSERT ON RandomDataBase 
FOR EACH ROW
DECLARE
result_number number := 0;
control_number number;
snils varchar(14) := '111-222-333 45';
sum number;

BEGIN
control_number := to_number(substr(snils, -2));
snils := substr(snils, 1, -3);
snils := replace(snils, '-');
sum := remainder((snils(1)*9 + snils(2)*8 + 
    snils(3)*7 + snils(4)*6 + 
    snils(5)*5 + snils(6)*4 + 
    snils(7)*3 + snils(8)*2 + snils(9)*1), 101);
IF(sum = 100 or sum = 101) THEN
    sum := 0;
ELSIF(sum = 102) THEN
    sum := 1;
ELSIF(sum > 102) THEN
    sum := remainder((snils(1)*9 + snils(2)*8 + 
    snils(3)*7 + snils(4)*6 + 
    snils(5)*5 + snils(6)*4 + 
    snils(7)*3 + snils(8)*2 + snils(9)*1), 101);
ELSE
    sum := remainder((snils(1)*9 + snils(2)*8 + 
    snils(3)*7 + snils(4)*6 + 
    snils(5)*5 + snils(6)*4 + 
    snils(7)*3 + snils(8)*2 + snils(9)*1), 101);
END IF;
IF(control_number = sum) THEN
    result_number := 1;
END IF;
    INSERT INTO RandomDataBase (snils_number, snils_result) VALUES (snils, result_number);
END;
ALTER TRIGGER CHECKSNILSTRIGGER ENABLE;
