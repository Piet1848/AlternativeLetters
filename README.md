# Alternative Letters

A reading interface for experimenting with a compact, animated representation of text. The **Original text** view keeps the full wording selectable and available for rereading. **Alternative letters** is an experimental encoding: groups of consonants alternate in one position, while vowel colors alternate. A vowel at the start of a group is also shown as a character. This representation is lossy at any single moment, relies on color, and has not been shown to increase reading speed or comprehension.

Paste or type text at the top, or choose an example and select **Load example**. Choose a view and adjust the text size. Animation starts paused; use **Play animation** and adjust the frame duration to explore it. The original text remains in the editor as a reference. The reading timer reports approximate words per minute (whitespace-separated words divided by elapsed time). It does not measure comprehension, so check your understanding independently. Editing the text or changing the view resets the timer. Nothing is saved or sent to a service.

Use **Hide original text** to put the editor out of sight, and **Show original text** to bring it back. In the alternative view, enable **Hover hints** and hold the pointer over a word to see its original spelling.

## Research and design choices

- Rereading can support comprehension: in an experiment, preventing regressions to earlier text reduced comprehension ([Schotter, Tran and Rayner, 2014](https://pubmed.ncbi.nlm.nih.gov/24747167/)). The original view therefore preserves the entire text instead of forcing a one-way sequence.
- Visual cues may help direct attention in particular instructional materials, but that does not prove that coloring every vowel or compressing letters improves reading ([signaling study](https://pmc.ncbi.nlm.nih.gov/articles/PMC8354981/)). The encoding is optional and should be evaluated against normal text.
- A study of bold word beginnings found no reading-time benefit ([Snell, 2024](https://pubmed.ncbi.nlm.nih.gov/38723450/)). Visual novelty alone should not be assumed to improve reading.
- Color should not be the sole means of conveying information ([W3C guidance](https://www.w3.org/WAI/WCAG21/Understanding/use-of-color.html)). The original view supplies the actual letters for readers who cannot distinguish the colors; the experimental view itself is not color-independent.

To compare views, use different passages of similar length and difficulty, counterbalance their order, and assess comprehension as well as time. The built-in timer is a personal exploration aid, not a controlled study.

## Run

Double-click **index.html** in this folder. It opens in your browser and works offline; there is nothing to install.

The original Windows Forms source is retained in the AlternativeLetters folder for reference. The browser version is the easiest way to use the project.
