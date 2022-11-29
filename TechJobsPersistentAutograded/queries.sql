--Part 1
SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS
WHERE table_name = "jobs";
--Part 2
SELECT employers.Name AS Employer, Location FROM employers 
WHERE Location = "Saint Louis";
--Part 3
SELECT skills.Name, skills.Description FROM skills
INNER JOIN jobskills ON skills.Id = jobskills.SkillId
GROUP BY skills.Name
ORDER BY skills.Name ASC;