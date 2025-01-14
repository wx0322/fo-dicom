﻿// Copyright (c) 2012-2021 fo-dicom contributors.
// Licensed under the Microsoft Public License (MS-PL).

using System.Text;

namespace FellowOakDicom.Log
{

    public static class Extensions
    {

        public static void WriteToLog(this DicomDataset dataset, Logger log, LogLevel level)
        {
            var logger = new DicomDatasetLogger(log, level);
            new DicomDatasetWalker(dataset).Walk(logger);
        }

        public static void WriteToLog(this DicomFile file, Logger log, LogLevel level)
        {
            var logger = new DicomDatasetLogger(log, level);
            new DicomDatasetWalker(file.FileMetaInfo).Walk(logger);
            new DicomDatasetWalker(file.Dataset).Walk(logger);
        }

        public static string WriteToString(this DicomDataset dataset)
        {
            var log = new StringBuilder();
            var dumper = new DicomDatasetDumper(log);
            new DicomDatasetWalker(dataset).Walk(dumper);
            return log.ToString();
        }

        public static string WriteToString(this DicomFile file)
        {
            var log = new StringBuilder();
            var dumper = new DicomDatasetDumper(log);
            new DicomDatasetWalker(file.FileMetaInfo).Walk(dumper);
            new DicomDatasetWalker(file.Dataset).Walk(dumper);
            return log.ToString();
        }
    }
}
