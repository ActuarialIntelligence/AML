using AML.Domain;
using AML.Infrastructure.Readers;
using AML.Infrastructure.Readers.Interfaces;
using System;
using System.Collections.Generic;
using Unity;
using AML.Infrastructure.Writers.Interfaces;
using AML.Infrastructure.Writers;
using AML.Serialization.Interfaces;
using AML.Serialization;
using AML.infrastructure.Data.Dto;
using AML.Infrastructure.Connections;
using AML.Infrastructure.Readers.GGE;

namespace AML.IOC ///Inversion of control
{
    /// <summary>
    /// Service Locator
    /// </summary>
    public static class DependencyResolution
    {
        public static UnityContainer container { get; private set; }
        public static void ConstructContainer()
        {
            container = new UnityContainer();
        }
        //DJExcelFileReader: IDataReader<IList<DJListRow>>,IDataReaderWorksheetParametreic<IList<DJListRow>>
        public static ISerialize<InputlistPair> GetGESerializer(string sourceFilePerson,
        string worksheetNamePerson,
        string sourceFileEntity,
        string worksheetNameEntity)
        {
            var reader = new DJExcelFileReader();
            var serializer = new GEFileSerializer(reader, sourceFilePerson, worksheetNamePerson, sourceFileEntity, worksheetNameEntity);// Resolving using constructor DI.
            return serializer;
        }
        public static IDataReader<IList<DJListRow>> GetDJExcelFileReader()
        {
            var reader = new DJExcelFileReader();
            return reader;
        }

        public static IDataReaderWorksheetParametreic<IList<DJListRow>> GetGEFileReader()
        {
            var reader = new DJExcelFileReader();
            return reader;
        }

        public static IKeyParametricDataReader<string> GetFieldMappingsReader()
        {
            container.RegisterType <IKeyParametricDataReader<string>, FieldMappingsReader>();
            var reader = container.Resolve<FieldMappingsReader>();// Resolving using constructor DI.
            return reader;
        }

        public static IDataWrite<IList<FieldNameInputValuePairObject>> GetFICOFileWriter(string path, string pathext, string headerText)
        {
            Console.WriteLine("Beginning writer constructions: {0} {1}.", path, pathext);
            var con = new CsvDataWriterConnection<FICOFieldsWriteDto>(headerText);
            var conExt = new CsvDataWriterConnection<FICOFieldsDelimitedDto>(headerText);
            var writer = new FICOFileWriter<FICOFieldsDto, FICOFieldsWriteDto, FICOFieldsDelimitedDto>(con, conExt, path, pathext);
            return writer;
        }

        public static IDataWrite<IList<FieldNameInputValuePairObject>> GetGERelationshipWriter(string path, string pathext, string headerText)
        {
 
            var con = new CsvDataWriterConnection<GERelationshipFieldQuotedDto>(headerText);
            var conExt = new CsvDataWriterConnection<FICOFieldsDelimitedDto>(headerText);
            var writer = new FICOFileWriter<GERelationshipDto, GERelationshipFieldQuotedDto, FICOFieldsDelimitedDto>(con, conExt, path, pathext);
            return writer;
        }

        public static IPairSerialize<IList<DJListRow>, InputlistPair> GetFICOSerializer()
        {
            var serializer = container.Resolve<LibFinFICOFileSerializer>();
            return serializer;
        }

        public static ISerialize<InputlistPair> GetGGESerializer(string csvLocation,string sourceTemp,string sourceTempworksheetName) 
        {
            Console.WriteLine("Beginning Serialization: {0} {1} {2}.", csvLocation, sourceTemp, sourceTempworksheetName);
            var csvConnection = new CsvDataReaderConnection<StringArrayDto>(csvLocation);
            var workSheetReader = new DJExcelFileReader();
           var ggeReader = new GGEReader(csvConnection, workSheetReader);
            return new GGEFileSerializer(ggeReader, csvLocation, sourceTemp, sourceTempworksheetName);
        }

        public static ISerialize<InputlistPair> GetGGESerializer(string sourceExcelPerm, string sourcePermworksheetName, string sourceExcelTemp, string sourceTempworksheetName)
        {
            Console.WriteLine("Beginning Serialization: {0} {1} {2} {3}.", sourceExcelPerm, sourcePermworksheetName, sourceExcelTemp, sourceTempworksheetName);
            var workSheetReaderPerm = new DJExcelFileReader();
            var workSheetReaderTemp = new DJExcelFileReader();
            var ggeReader = new GGEDoubleExcelFileReader(workSheetReaderPerm, workSheetReaderTemp);
            return new GGEFileSerializer(ggeReader,sourceExcelPerm, sourcePermworksheetName, sourceExcelTemp, sourceTempworksheetName);
        }

    }
}
