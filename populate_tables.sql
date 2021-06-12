USE [gymTEC_DB]

EXEC CreateUpdateDelete_SpaTreatment @nombre = 'Masaje descarga muscular', @StatementType = 'INSERT';
EXEC CreateUpdateDelete_SpaTreatment @nombre = 'Masaje relajante', @StatementType = 'INSERT';
EXEC CreateUpdateDelete_SpaTreatment @nombre = 'Masaje sauna', @StatementType = 'INSERT';
EXEC CreateUpdateDelete_SpaTreatment @nombre = 'Baños a vapor', @StatementType = 'INSERT';

EXEC CreateUpdateDelete_Position @nombre = 'Administrador', @StatementType = 'INSERT';
EXEC CreateUpdateDelete_Position @nombre = 'Instructor', @StatementType = 'INSERT';
EXEC CreateUpdateDelete_Position @nombre = 'Dependiente Spa', @StatementType = 'INSERT';
EXEC CreateUpdateDelete_Position @nombre = 'Dependiente tienda', @StatementType = 'INSERT';

EXEC CreateUpdateDelete_Service @nombre = 'Indoor Cycling', @StatementType = 'INSERT';
EXEC CreateUpdateDelete_Service @nombre = 'Pilates', @StatementType = 'INSERT';
EXEC CreateUpdateDelete_Service @nombre = 'Yoga', @StatementType = 'INSERT';
EXEC CreateUpdateDelete_Service @nombre = 'Zumba', @StatementType = 'INSERT';
EXEC CreateUpdateDelete_Service @nombre = 'Natación', @StatementType = 'INSERT';

EXEC CreateUpdateDelete_EquipmentType @nombre = 'Cintas de correr', @StatementType = 'INSERT';
EXEC CreateUpdateDelete_EquipmentType @nombre = 'Bicicletas estacionarias', @StatementType = 'INSERT';
EXEC CreateUpdateDelete_EquipmentType @nombre = 'Multigimnasios', @StatementType = 'INSERT';
EXEC CreateUpdateDelete_EquipmentType @nombre = 'Remos', @StatementType = 'INSERT';
EXEC CreateUpdateDelete_EquipmentType @nombre = 'Pesas', @StatementType = 'INSERT';
