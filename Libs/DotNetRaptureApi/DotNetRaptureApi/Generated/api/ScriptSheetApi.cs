/**
 * Copyright (C) 2011-2013 Incapture Technologies LLC
 * 
 * This is an autogenerated license statement. When copyright notices appear below
 * this one that copyright supercedes this statement.
 *
 * Unless required by applicable law or agreed to in writing, software is distributed
 * on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express
 * or implied.
 *
 * Unless explicit permission obtained in writing this software cannot be distributed.
 */

/**
 * This is an autogenerated file. You should not edit this file as any changes
 * will be overwritten.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetRaptureAPI.Common.FixedTypes;

namespace DotNetRaptureAPI
{

public interface ScriptSheetApi {
     /**
     * 
     * 
     */
     void createSheetRepo(string sheetURI, string config);

     /**
     * 
     * 
     */
     SheetRepoConfig getSheetRepoConfig(string sheetURI);

     /**
     * 
     * 
     */
     List<SheetRepoConfig> getSheetRepoConfigs();

     /**
     * 
     * 
     */
     RaptureSheet createSheet(string sheetURI);

     /**
     * 
     * 
     */
     RaptureSheet deleteSheet(string sheetURI);

     /**
     * 
     * 
     */
     bool sheetExists(string sheetURI);

     /**
     * 
     * 
     */
     void deleteSheetRepo(string repoURI);

     /**
     * 
     * 
     */
     bool sheetRepoExists(string repoURI);

     /**
     * 
     * 
     */
     Dictionary<string, RaptureFolderInfo> listSheetsByUriPrefix(string uriPrefix, int depth);

     /**
     * 
     * 
     */
     List<string> deleteSheetsByUriPrefix(string uriPrefix);

     /**
     * 
     * 
     */
     string setSheetCell(string sheetURI, int row, int column, string value, int tabId);

     /**
     * 
     * 
     */
     void setBlock(string sheetURI, int startRow, int startColumn, List<string> values, int height, int width, int tabId);

     /**
     * 
     * 
     */
     string getSheetCell(string sheetURI, int row, int column, int tabId);

     /**
     * 
     * 
     */
     List<RaptureSheetCell> findCellsByEpoch(string sheetURI, int tabId, long epoch);

     /**
     * 
     * 
     */
     SheetAndMeta getSheetAndMeta(string sheetURI);

     /**
     * 
     * 
     */
     void exportSheetAsPdf(string sheetURI, string blobURI);

     /**
     * 
     * 
     */
     List<RaptureSheetStyle> getAllStyles(string sheetURI);

     /**
     * 
     * 
     */
     void removeStyle(string sheetURI, string styleName);

     /**
     * 
     * 
     */
     RaptureSheetStyle createStyle(string sheetURI, RaptureSheetStyle style);

     /**
     * 
     * 
     */
     List<RaptureSheetScript> getAllScripts(string sheetURI);

     /**
     * 
     * 
     */
     void removeScript(string sheetURI, string scriptName);

     /**
     * 
     * 
     */
     RaptureSheetScript createScript(string sheetURI, string scriptName, RaptureSheetScript script);

     /**
     * 
     * 
     */
     void runScriptOnSheet(string sheetURI, string scriptName);

     /**
     * 
     * 
     */
     RaptureSheetScript getSheetScript(string sheetURI, string scriptName);

     /**
     * 
     * 
     */
     string exportSheetAsScript(string sheetURI);

     /**
     * 
     * 
     */
     List<RaptureSheetRange> getSheetNamedSelections(string sheetURI);

     /**
     * 
     * 
     */
     void deleteSheetNamedSelection(string sheetURI, string rangeName);

     /**
     * 
     * 
     */
     RaptureSheetRange createSheetNamedSelection(string sheetURI, string rangeName, RaptureSheetRange range);

     /**
     * 
     * 
     */
     List<RaptureSheetNote> getSheetNotes(string sheetURI);

     /**
     * 
     * 
     */
     void deleteSheetNote(string sheetURI, string noteId);

     /**
     * 
     * 
     */
     RaptureSheetNote createSheetNote(string sheetURI, RaptureSheetNote note);

     /**
     * 
     * 
     */
     void cloneSheet(string sheetURI, string newSheetURI);

     /**
     * 
     * 
     */
     List<RaptureSheetRow> getSheetNamedSelection(string sheetURI, string rangeName);

     /**
     * 
     * 
     */
     void deleteSheetColumn(string sheetURI, int column);

     /**
     * 
     * 
     */
     void deleteSheetRow(string sheetURI, int row);

     /**
     * 
     * 
     */
     void deleteSheetCell(string sheetURI, int row, int column, int tabId);

}
}

