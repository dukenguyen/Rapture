/**
 * The MIT License (MIT)
 *
 * Copyright (C) 2011-2016 Incapture Technologies LLC
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */
package rapture.common;

import java.util.List;

/**
 * Note that this class is referenced in types.api - any changes to this file should be reflected there.
**/

public class TableQuery implements RaptureTransferObject {
    public List<TableSelect> getFieldTests() {
        return fieldTests;
    }

    public void setFieldTests(List<TableSelect> fieldTests) {
        this.fieldTests = fieldTests;
    }

    public List<String> getFieldReturns() {
        return fieldReturns;
    }

    public void setFieldReturns(List<String> fieldReturns) {
        this.fieldReturns = fieldReturns;
    }

    public List<TableColumnSort> getSortFields() {
        return sortFields;
    }

    public void setSortFields(List<TableColumnSort> sortFields) {
        this.sortFields = sortFields;
    }

    public int getSkip() {
        return skip;
    }

    public void setSkip(int skip) {
        this.skip = skip;
    }

    public int getLimit() {
        return limit;
    }

    public void setLimit(int limit) {
        this.limit = limit;
    }

    private List<TableSelect> fieldTests;
    private List<String> fieldReturns;
    private List<TableColumnSort> sortFields;
    private int skip = 0;
    private int limit = 0;
}
