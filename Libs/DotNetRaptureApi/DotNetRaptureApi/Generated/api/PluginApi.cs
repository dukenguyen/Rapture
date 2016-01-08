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
    public interface PluginApi {
     /**
     * Lists plugins in the system.
     * 
     */
     List<PluginConfig> getInstalledPlugins(CallingContext context);

     /**
     * Retrieves the manifest for a plugin.
     * 
     */
     PluginManifest getPluginManifest(CallingContext context, string manifestUri);

     /**
     * Retrieves the manifest for a plugin.
     * 
     */
     void recordPlugin(CallingContext context, PluginConfig plugin);

     /**
     * Installs the plugin and updates the registry.
     * 
     */
     void installPlugin(CallingContext context, PluginManifest manifest, Dictionary<string, PluginTransportItem> payload);

     /**
     * Installs a single item from a plugin to allow clients to operate in a low-memory environment
     * 
     */
     void installPluginItem(CallingContext context, string pluginName, PluginTransportItem item);

     /**
     * Removes a plugin.
     * 
     */
     void uninstallPlugin(CallingContext context, string name);

     /**
     * Removes an item from a plugin.
     * 
     */
     void uninstallPluginItem(CallingContext context, PluginTransportItem item);

     /**
     * Removes plugin Manifest but does not uninstall any referenced items.
     * 
     */
     void deletePluginManifest(CallingContext context, string manifestUri);

     /**
     * Gets the encoding for a Rapture object given its URI.
     * 
     */
     PluginTransportItem getPluginItem(CallingContext context, string uri);

     /**
     * Verifies that the contents of a plugin match the hashes in the manifest.
     * 
     */
     Dictionary<string, string> verifyPlugin(CallingContext context, string plugin);

     /**
     * create an empty manifest on the server with version 0.0.0
     * 
     */
     void createManifest(CallingContext context, string pluginName);

     /**
     * add an object on the server to a plugin manifest on the server
     * 
     */
     void addManifestItem(CallingContext context, string pluginName, string uri);

     /**
     * add uris within the specified docpath root. If no type is specifed in the uri, use all four of doc, blob, series, and sheet. Example1: //myProject/myfolder adds all four types. Example2: blob://myproject/myfolder adds only blobs
     * 
     */
     void addManifestDataFolder(CallingContext context, string pluginName, string uri);

     /**
     * remove uris within the specified path. If no type is specifed in the uri, use all four of doc, blob, series, and sheet.
     * 
     */
     void removeManifestDataFolder(CallingContext context, string pluginName, string uri);

     /**
     * refresh the MD5 checksums in the manifest and set the version for a manifest on the server
     * 
     */
     void setManifestVersion(CallingContext context, string pluginName, string version);

     /**
     * remove an item from the manifest of a plugin on the server
     * 
     */
     void removeItemFromManifest(CallingContext context, string pluginName, string uri);

     /**
     * Export a plugin as a single blob. We pass in a parent path; the blob will be generated somewhere under that path, in a non-predictable location. The location is returned.
     * 
     */
     string exportPlugin(CallingContext context, string pluginName, string path);

	}
}
