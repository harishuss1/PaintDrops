# Performance Optimization

## Surface and Drops Values Used
- **Surface Values**: 500x500 & 2000x2000
- **Drops Values**: 10 & 1000

## Pre-Optimizations
This is the performance before all the performance changes.

### Debug
**PaintDropSimulation Benchmarking:**
- **Surface (500x500) with 100 drops**: Time taken: **81 ms**
- **Surface (500x500) with 1000 drops**: Time taken: **2433 ms**
- **Surface (2000x2000) with 100 drops**: Time taken: **55 ms**
- **Surface (2000x2000) with 1000 drops**: Time taken: **4519 ms**

### Release
**PaintDropSimulation Benchmarking:**
- **Surface (500x500) with 100 drops**: Time taken: **45 ms**
- **Surface (500x500) with 1000 drops**: Time taken: **1072 ms**
- **Surface (2000x2000) with 100 drops**: Time taken: **40 ms**
- **Surface (2000x2000) with 1000 drops**: Time taken: **3118 ms**

---

## Post-Optimizations
This is the performance after all the performance changes.

### Debug
**PaintDropSimulation Benchmarking:**
- **Surface (500x500) with 100 drops**: Time taken: **65 ms**
- **Surface (500x500) with 1000 drops**: Time taken: **725 ms**
- **Surface (2000x2000) with 100 drops**: Time taken: **22 ms**
- **Surface (2000x2000) with 1000 drops**: Time taken: **1062 ms**

### Release
**PaintDropSimulation Benchmarking:**
- **Surface (500x500) with 100 drops**: Time taken: **68 ms**
- **Surface (500x500) with 1000 drops**: Time taken: **155 ms**
- **Surface (2000x2000) with 100 drops**: Time taken: **9 ms**
- **Surface (2000x2000) with 1000 drops**: Time taken: **239 ms**

---
## Discussion

### Debug
Pre-optimization, the task that took the longest was the **2000x2000** surface with **1000** drops, taking **4519 ms**. 
After optimization, the same task was reduced by almost **3x**, now taking **1062 ms**.

### Release
Pre-optimization, the task that took the longest was the **2000x2000** surface with **1000** drops, taking **3118 ms**. 
Post-optimization, the same task was reduced by almost **12x**, now taking **239 ms**.

