[![Build and Test](https://github.com/mszczer/tech-interview-kit/actions/workflows/dotnet_ci.yml/badge.svg)](https://github.com/mszczer/tech-interview-kit/actions/workflows/dotnet_ci.yml)
[![Codacy Badge](https://app.codacy.com/project/badge/Grade/931411cd0c0c4a88a7fbd8dc6cac812b)](https://app.codacy.com/gh/mszczer/tech-interview-kit/dashboard?utm_source=gh&utm_medium=referral&utm_content=&utm_campaign=Badge_grade)
[![Codacy Badge](https://app.codacy.com/project/badge/Coverage/931411cd0c0c4a88a7fbd8dc6cac812b)](https://app.codacy.com/gh/mszczer/tech-interview-kit/dashboard?utm_source=gh&utm_medium=referral&utm_content=&utm_campaign=Badge_coverage)
![License](https://img.shields.io/github/license/mszczer/tech-interview-kit)
![Platform](https://img.shields.io/badge/platform-.NET-512BD4)
![GitHub commit activity](https://img.shields.io/github/commit-activity/m/mszczer/tech-interview-kit)
![GitHub last commit](https://img.shields.io/github/last-commit/mszczer/tech-interview-kit)
![GitHub top language](https://img.shields.io/github/languages/top/mszczer/tech-interview-kit)

# Tech Interview Kit (Data Structures & Algorithms in C#)

A curated set of **data structures and algorithms** solutions implemented in **C#**, with a focus on **clarity**, **testability**, and **consistent patterns**—meant to serve as a personal reference and a practical **tech interview preparation** companion.

---

<a id="table-of-contents"></a>
## Table of Contents
- [Purpose / Vision](#purpose-vision)
- [Project Structure](#project-structure)
- [Algorithms Problem Set](#algorithms-problem-set)
  - [Easy](#easy)
  - [Medium](#medium)
  - [Hard](#hard)
- [Tech Stack](#tech-stack)
- [Related Resources / Inspiration](#related-resources)
- [License](#license)

---

<a id="purpose-vision"></a>
## Purpose / Vision
The goal of this repository is to maintain a **high-signal** collection of solutions that are easy to revisit: each problem should have a clean implementation, predictable naming, and (where practical) **automated tests**. Over time, this becomes a personal “playbook” for common interview patterns (arrays, strings, linked lists, stacks/queues, trees, sorting, etc.).

---

<a id="project-structure"></a>
## Project Structure
```text
tech-interview-kit/
├─ Coding.Challenges/                 # Algorithm implementations
├─ Coding.Challenges.Tests/           # Unit tests for challenges
├─ Coding.Challenges.Common/          # Shared utilities (if any)
├─ Coding.Challenges.Common.Tests/    # Tests for shared utilities
├─ .github/workflows/                 # CI configuration (GitHub Actions)
├─ Tech Interview Kit.sln             # .NET solution
└─ README.md                          # Project documentation
```

---

<a id="algorithms-problem-set"></a>
## Algorithms Problem Set

> This section is generated from the `Coding.Challenges/` directory.

<!-- ALGORITHMS_PROBLEM_SET:START -->
<a id="easy"></a>
### Easy
- [Bitonic Array](Coding.Challenges/Easy/BitonicArray.cs)
- [Calculate Power Function](Coding.Challenges/Easy/PowerFunction.cs)
- [Merge Two Binary Trees](Coding.Challenges/Easy/MergeTwoBinaryTrees.cs)
- [Merge Two Sorted Lists](Coding.Challenges/Easy/MergeSortedLists.cs)
- [Min Depth of Binary Tree](Coding.Challenges/Easy/MinDepthOfBinaryTree.cs)
- [Min Stack](Coding.Challenges/Easy/MinStack.cs)
- [Minimum Absolute Difference in BST](Coding.Challenges/Easy/MinDifferenceInBst.cs)
- [Path Sum in Binary Tree](Coding.Challenges/Easy/PathSumInBinaryTree.cs)
- [Range in a Sorted Array](Coding.Challenges/Easy/RangeInSortedArray.cs)
- [Reverse Bits](Coding.Challenges/Easy/ReverseBits.cs)
- [Sorted Array to Balanced BST](Coding.Challenges/Easy/SortedArrayToBalancedBst.cs)
- [Swap List Nodes](Coding.Challenges/Easy/SwapListNodes.cs)
- [Test Zeroes To End](Coding.Challenges/Easy/TestZeroesToEnd.cs)
- [Wave Array](Coding.Challenges/Easy/WaveArray.cs)

<a id="medium"></a>
### Medium
- [Roman To Integer](Coding.Challenges/Medium/RomanToInteger.cs)
- [Sorting Algorithms](Coding.Challenges/Medium/SortedArray.cs)

<a id="hard"></a>
### Hard
- (coming soon)
<!-- ALGORITHMS_PROBLEM_SET:END -->

---

<a id="tech-stack"></a>
## Tech Stack
- **Language:** C#
- **Platform:** .NET
- **Testing:** NUnit
- **Coverage:** Coverlet (collector)
- **CI:** GitHub Actions
- **Code Quality:** Codacy

---

<a id="related-resources"></a>
## Related Resources / Inspiration
- AfterAcademy — Data Structures & Algorithms problem set: https://afteracademy.com/tech-interview/
- NeetCode — curated interview patterns & practice roadmap: https://neetcode.io/
- LeetCode — practice platform: https://leetcode.com/
- TheAlgorithms — open-source algorithms reference: https://github.com/TheAlgorithms
- Microsoft .NET docs: https://learn.microsoft.com/dotnet/

---

<a id="license"></a>
## License
The scripts and documentation in this project are released under the [MIT License](LICENSE).
