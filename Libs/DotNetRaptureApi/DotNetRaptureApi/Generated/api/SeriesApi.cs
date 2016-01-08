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
    public interface SeriesApi {
     /**
     * Creates a repository for series data.
     * 
     */
     void createSeriesRepo(CallingContext context, string seriesRepoUri, string config);

     /**
     * Check for the existence of a given repository
     * 
     */
     bool seriesRepoExists(CallingContext context, string seriesRepoUri);

     /**
     * Check for the existence of a given series
     * 
     */
     bool seriesExists(CallingContext context, string seriesUri);

     /**
     * Fetches the series repository config, or null if the repository is not found.
     * 
     */
     SeriesRepoConfig getSeriesRepoConfig(CallingContext context, string seriesRepoUri);

     /**
     * Fetch a list of all series repositories.
     * 
     */
     List<SeriesRepoConfig> getSeriesRepoConfigs(CallingContext context);

     /**
     * This method removes a Series Repository and its data from the Rapture system. There is no undo.
     * 
     */
     void deleteSeriesRepo(CallingContext context, string seriesRepoUri);

     /**
     * This method removes a Series and its data from the Rapture system. There is no undo.
     * 
     */
     void deleteSeries(CallingContext context, string seriesRepoUri);

     /**
     * Recursively removes all series repositories that are children of the given Uri.
     * 
     */
     List<string> deleteSeriesByUriPrefix(CallingContext context, string seriesUri);

     /**
     * Adds one point of floating-point data to a given series.
     * 
     */
     void addDoubleToSeries(CallingContext context, string seriesUri, string pointKey, double pointValue);

     /**
     * Adds one point of type long to a given series.
     * 
     */
     void addLongToSeries(CallingContext context, string seriesUri, string pointKey, long pointValue);

     /**
     * Adds one point of string data to a given series.
     * 
     */
     void addStringToSeries(CallingContext context, string seriesUri, string pointKey, string pointValue);

     /**
     * Adds one point containing a JSON-encoded structure to a given series.
     * 
     */
     void addStructureToSeries(CallingContext context, string seriesUri, string pointKey, string pointValue);

     /**
     * Adds a list of points of floating-point data to a given series.
     * 
     */
     void addDoublesToSeries(CallingContext context, string seriesUri, List<string> pointKeys, List<double> pointValues);

     /**
     * Adds a list of points of type long to a given series.
     * 
     */
     void addLongsToSeries(CallingContext context, string seriesUri, List<string> pointKeys, List<long> pointValues);

     /**
     * Adds a list of string points to a given series.
     * 
     */
     void addStringsToSeries(CallingContext context, string seriesUri, List<string> pointKeys, List<string> pointValues);

     /**
     * Adds a list of points containing JSON-encoded structures to a series.
     * 
     */
     void addStructuresToSeries(CallingContext context, string seriesUri, List<string> pointKeys, List<string> pointValues);

     /**
     * Delete a list of points from a series.
     * 
     */
     void deletePointsFromSeriesByPointKey(CallingContext context, string seriesUri, List<string> pointKeys);

     /**
     * Removes all points in a series, then removes the series from the directory listing for its parent folder.
     * 
     */
     void deletePointsFromSeries(CallingContext context, string seriesUri);

     /**
     * Retrieves the last point in a series.
     * 
     */
     SeriesPoint getLastPoint(CallingContext context, string seriesUri);

     /**
     * If the series size is less than the maximum batch size (one million points by default), this returns all points in a list. If the series is larger, an exception is thrown.
     * 
     */
     List<SeriesPoint> getPoints(CallingContext context, string seriesUri);

     /**
     * Gets one page of data from a series
     * 
     */
     List<SeriesPoint> getPointsAfter(CallingContext context, string seriesUri, string startColumn, int maxNumber);

     /**
     * Gets one page of data and reverses the normal sort order
     * 
     */
     List<SeriesPoint> getPointsAfterReverse(CallingContext context, string seriesUri, string startColumn, int maxNumber);

     /**
     * Gets one page of data from a series range.
     * 
     */
     List<SeriesPoint> getPointsInRange(CallingContext context, string seriesUri, string startColumn, string endColumn, int maxNumber);

     /**
     * Gets the entire contents of a series and casts each value to type Double.
     * 
     */
     List<SeriesDouble> getPointsAsDoubles(CallingContext context, string seriesUri);

     /**
     * Gets one page of data from a series and casts each value to type Double.
     * 
     */
     List<SeriesDouble> getPointsAfterAsDoubles(CallingContext context, string seriesUri, string startColumn, int maxNumber);

     /**
     * Gets one page of data from a series range and casts each value to type Double.
     * 
     */
     List<SeriesDouble> getPointsInRangeAsDoubles(CallingContext context, string seriesUri, string startColumn, string endColumn, int maxNumber);

     /**
     * Gets the entire contents of a series and casts each value to type String.
     * 
     */
     List<SeriesString> getPointsAsStrings(CallingContext context, string seriesUri);

     /**
     * Gets one page of data from a series and casts each value to type String.
     * 
     */
     List<SeriesString> getPointsAfterAsStrings(CallingContext context, string seriesUri, string startColumn, int maxNumber);

     /**
     * Gets one page of data from a series range and casts each value to type String.
     * 
     */
     List<SeriesString> getPointsInRangeAsStrings(CallingContext context, string seriesUri, string startColumn, string endColumn, int maxNumber);

     /**
     * Executes a series function program and returns its default output.
     * 
     */
     List<SeriesPoint> runSeriesScript(CallingContext context, string scriptContent, List<string> arguments);

     /**
     * Executes a series function program and returns success status only.
     * 
     */
     void runSeriesScriptQuiet(CallingContext context, string scriptContent, List<string> arguments);

     /**
     * Returns full pathnames for an entire subtree as a map of path to RFI.
     * 
     */
     Dictionary<string, RaptureFolderInfo> listSeriesByUriPrefix(CallingContext context, string uriPrefix, int depth);

	}
}
