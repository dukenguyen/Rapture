/**
 * The MIT License (MIT)
 *
 * Copyright (c) 2011-2016 Incapture Technologies LLC
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
package reflex.node;

import java.math.BigDecimal;
import java.util.List;

import reflex.IReflexHandler;
import reflex.ReflexException;
import reflex.Scope;
import reflex.debug.IReflexDebugger;
import reflex.value.ReflexValue;

public class UnaryMinusNode extends BaseNode {

    private ReflexNode exp;

    public UnaryMinusNode(int lineNumber, IReflexHandler handler, Scope s, ReflexNode e) {
        super(lineNumber, handler, s);
        exp = e;
    }

    @Override
    public ReflexValue evaluate(IReflexDebugger debugger, Scope scope) {
        debugger.stepStart(this, scope);
        ReflexValue v = exp.evaluate(debugger, scope);

        if (!v.isNumber()) {
            throw new ReflexException(lineNumber, "illegal expression: " + this);
        }
        ReflexValue retVal;
        if (v.isInteger()) {
            retVal = new ReflexValue(-v.asInt());
        } else {
            retVal = new ReflexValue(BigDecimal.ZERO.subtract(v.asBigDecimal()));
        }
        debugger.stepEnd(this, retVal, scope);
        return retVal;
    }

    // Special case for lists
    public ReflexValue removeFromList(IReflexDebugger debugger, Scope scope, ReflexValue list) {
        debugger.stepStart(this, scope);
        if (!list.isList()) {
            throw new ReflexException(lineNumber, "Expected list but got " + list.getTypeAsString());
        }
        ReflexValue v = exp.evaluate(debugger, scope);
        List<ReflexValue> newList = list.asList();
        if (!newList.contains(v)) {
            throw new ReflexException(lineNumber, "List does not contain the value " + v.toString());
        }
        newList.remove(v);
        ReflexValue retVal = new ReflexValue(newList);
        debugger.stepEnd(this, retVal, scope);
        return retVal;
    }

    @Override
    public String toString() {
        return String.format("(-%s)", exp);
    }
}
